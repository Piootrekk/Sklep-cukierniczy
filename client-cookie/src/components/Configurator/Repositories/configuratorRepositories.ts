import { createApiHook } from "../../../services/useApi";
import { Ingredient } from "../../../storage/CustomCakeCont";

export const useCustomCookApi = createApiHook(api => async () => {
    return (await api.get('/customcake/getall')).data
})

export const useGetAllProducts = createApiHook(api => async () => {
    return (await api.get('/products/getall')).data
})

export const useGetAllIngredients = createApiHook(api => async () => {
    return (await api.get('/products/getallingridients')).data
})

export const useAddNewProduct = createApiHook(api => (data: Partial<Ingredient>) =>
    api.post('/products/addproduct', data)
)

export const useGetCategories = createApiHook(api => async () => {
    return (await api.get('/categorys/getcategorys')).data
})