import { AxiosRequestConfig, AxiosResponse } from "axios"
import axiosService from "./axiosService";

interface Api {
    get: <Response = any>(path: string, config?: AxiosRequestConfig) => Promise<AxiosResponse<Response>>
    post: <Response = any>(path: string, data?: any, config?: AxiosRequestConfig) => Promise<AxiosResponse<Response>>
    put: <Response = any>(path: string, data?: any, config?: AxiosRequestConfig) => Promise<AxiosResponse<Response>>
    delete: <Response = any>(path: string, config?: AxiosRequestConfig) => Promise<AxiosResponse<Response>>
}

export function useApi(): Api {
    const catchErrors = <F extends Function>(fn: F): F => {
        return (async function(...args: any[]) {
            try {
                return await fn(...args);
            }
            catch(error: any) {                    
                const data = error?.response?.data;

                throw data?.status || data;
            }
        }) as any;
    };

    const modifyConfig = (config?: AxiosRequestConfig): AxiosRequestConfig => {
        const token = localStorage.getItem('token');
        return {
            baseURL: 'http://localhost:5003/api',
            ...config,
            headers: {
                'content-type': 'application/json',
                Authorization: `Bearer ${token}`,
            },
        };
    };

    const api = {
        get: catchErrors(function <Response>(path: string, config?: AxiosRequestConfig) {
            return axiosService.get<Response>(path, modifyConfig(config));
        }),
        post: catchErrors(function <Response>(path: string, data?: any, config?: AxiosRequestConfig) {
            return axiosService.post<Response>(path, data, modifyConfig(config));
        }),
        put: catchErrors(function (path: string, data?: any, config?: AxiosRequestConfig) {
            return axiosService.put(path, data, modifyConfig(config));
        }),
        delete: catchErrors(function <Response> (path: string, config?: AxiosRequestConfig) {
            return axiosService.delete<Response>(path, modifyConfig(config));
        }),
    };

    return api;
}

export function createApiHook<T extends Function>(fn: (api: Api) => T): () => T {
    return function useApiHook() {
        const api = useApi();

        return fn(api);
    };
}