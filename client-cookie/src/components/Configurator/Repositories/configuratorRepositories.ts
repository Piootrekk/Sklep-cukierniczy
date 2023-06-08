import { createApiHook } from "../../../services/useApi";

export const useCustomCookApi = createApiHook(api => async () => {
    return (await api.get('/customcake/getall')).data
})

export const useGetAllIngredients = createApiHook(api => async () => {
    return (await api.get('/products/getallingridients')).data
})