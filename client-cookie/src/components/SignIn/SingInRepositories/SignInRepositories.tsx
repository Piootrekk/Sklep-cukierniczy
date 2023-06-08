import { createApiHook } from "../../../services/useApi";

export const useAuth = createApiHook(api => async (data: { username: string; password: string}) => {
        return (await api.post<{ value: number, success: boolean, returnMesage: string }>('/autentication/login', data)).data
    }
)