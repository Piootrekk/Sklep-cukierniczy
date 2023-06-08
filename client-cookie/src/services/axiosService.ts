import axios, { AxiosRequestConfig, AxiosResponse } from "axios"

const axiosGet = <Response = any>(
    path: string,
    config?: AxiosRequestConfig
) => {
    return axios.get<Response>(path, config);
};

const axiosPost = <T = any, R = AxiosResponse<T>>(path: string, data?: any, config?: AxiosRequestConfig) => {
    return axios.post<T, R>(path, data, config);
};

const axiosPut = (path: string, data?: any, config?: AxiosRequestConfig) => {
    return axios.put(path, data, config);
};

const axiosDelete = <Response = any>(path: string, config?: AxiosRequestConfig) => {
    return axios.delete<Response>(path, config);
};

const axiosMethods = {
    get: axiosGet,
    post: axiosPost,
    put: axiosPut,
    delete: axiosDelete,
};

export default axiosMethods;