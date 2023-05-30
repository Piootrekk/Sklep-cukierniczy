
import { Category } from "../models/Category";
import agent from "../api/agent";
import { action, makeAutoObservable, runInAction } from "mobx";

export default class CategoryStore
{
    categorys: Category[] = [];
    categoryRegistry = new Map<number,Category>();
    selectedCategory: Category | undefined = undefined;
    editMode =false;
    loading = false;
    loadingInitial = false;

    constructor()
    {
        makeAutoObservable(this)
    }

    LoadCategorys = async () =>
    {
        this.setLoadingInitial(true)
        try
        {
            this.categorys = await agent.Categorys.list();
            this.setLoadingInitial(false)
        }
        catch(error)
        {
            console.log(error);
            this.setLoadingInitial(false)
        }
    }

    setLoadingInitial = (state:boolean)=>
    {
        this.loadingInitial=state;
    }

    setLoading = (state:boolean)=>
    {
        this.loading=state;
    }

    selectCategory =(id: number) => {
        this.selectedCategory = this.categorys.find(x=>x.id===id);
    }

    cencleSelectedCategory = () =>
    {
        this.selectedCategory = undefined;
    }

    openForm = (id?: number) =>
    {
        id? this.selectCategory(id) : this.cencleSelectedCategory();
        this.editMode = true;
    }
    closeForm = () => 
    {
        this.editMode=false;
    }

    createCategory = async (category: Category) =>
    {
        this.setLoading(true)
        try
        {
            await agent.Categorys.create(category)
            runInAction(() =>
            {
                this.categorys.push(category);
                this.selectedCategory= category;
                this.editMode = false
            })
            this.setLoading(false)
        }
        catch(error)
        {
            console.log(error)
            this.setLoading(false)
            
        }
    }

    updateCategory = async (category:Category) =>
    {
        this.setLoading(true)
        try
        {
            await agent.Categorys.update(category)
            runInAction(() =>
            {
                this.categorys = [...this.categorys.filter(x=>x.id !== category.id),category];
                this.selectedCategory= category;
                this.editMode = false;
            })
            this.setLoading(false)
        }
        catch(error)
        {
            console.log(error)
            this.setLoading(false)
            
        }
    }

    deleteCategory = async (id: number) =>
    {
        this.setLoading(true)
        try
        {
            await agent.Categorys.delete(id);
            runInAction(()=>{
                this.categorys = [...this.categorys.filter(x=>x.id !== id)];
                if(this.selectedCategory?.id === id) this.cencleSelectedCategory();
            })
            this.setLoading(false)
        }catch(error)
        {
            console.log(error);
            this.setLoading(false)
        }
    }

}