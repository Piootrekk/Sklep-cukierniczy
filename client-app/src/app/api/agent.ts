import axios, { AxiosResponse } from "axios";
import { Category } from "../models/Category";

// const sleep=(delay: number) =>{
//     return new Promise((resolve)=>{
//         setTimeout(resolve,delay);
//     }
//     )
// }

axios.defaults.baseURL="http://localhost:5003";

// axios.interceptors.response.use(async response=>{
//     try {
//         await sleep(1000);
//         return response;
//     } catch (error) {
//         console.log(error);
//         return await Promise.reject(error);
//     }
// })

const responseValueGet=(response: AxiosResponse) => response.data.value;
const responseValueSent=(response: AxiosResponse) => response.data;

const requests =
{
    get:  (url: string) => axios.get(url).then(responseValueGet),
    post:  (url: string, body:{}) => axios.post(url,body).then(responseValueSent),
    put:  (url: string, body:{}) => axios.put(url,body).then(responseValueSent),
    del: (url: string) => axios.delete(url).then(responseValueSent)
}

const Categorys =
{
    list: ()=> requests.get("/api/categorys/adminget"),
    //details: (id: number) => requests.get<Category>(`/categorys/adminget${id}`),
    create: (category: Category) => requests.post("/api/categorys/adminpost", category),
    update: (category: Category) => requests.put("/api/categorys/adminput", category),
    delete: (id: number) => requests.del(`/api/categorys/admindelete/${id}`)
}

const agent =
{
    Categorys
}

export default agent;