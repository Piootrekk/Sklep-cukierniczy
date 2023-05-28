import { action, makeAutoObservable, makeObservable, observable } from "mobx";

export default class CategoryStore
{
    title ="Hello Mobx!";

    constructor()
    {
        makeAutoObservable(this)
    }

    setTitle=()=>
    {
        this.title = this.title+"!!";
    }
}