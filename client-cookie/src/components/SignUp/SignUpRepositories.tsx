import { createApiHook } from "../../services/useApi";

export const useRegistrator = createApiHook(api => async (data: 
    {   username: string,
        email: string,
        password: string,
        confirmPassword: string,
        phoneNumber: string,
        streetName: string,
        cityName: string,
        houseNumber: string,
        postalCode: string,
        firstName: string,
        lastName: string,
        role: {
          id: number,
          name: string,
          level: number,
          isActive: boolean,
          isDeleted: boolean
        }}
    ) => {
        return (await api.post<{ value: number, success: boolean, returnMesage: string }>('/autentication/register', data)).data
    }
)