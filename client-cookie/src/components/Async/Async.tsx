import {useEffect, useState} from "react";
interface AsyncProps<Data> {
    children: (data: Data) => JSX.Element
    action: () => Promise<Data>
    onLoad?: (data: Data) => void
    deps?: Array<any>
    showLoader?: boolean
}

export default function Async<Data>(props: AsyncProps<Data>) {
    const {onLoad = () => {}, deps = [], showLoader = true} = props;
    const [loading, setLoading] = useState(showLoader);
    const [success, setSuccess] = useState(false);
    const [result, setResult] = useState<Data>();

    useEffect(() => {
        let cancelled = false;

        showLoader && setLoading(true);
        props.action()
            .then(result => {
                if (!cancelled) {
                    setResult(result);
                    setLoading(false);
                    setSuccess(true);
                    onLoad(result);
                }
            })
            .catch(error => {
                if (!cancelled) {
                    error && console.log(error);
                    setLoading(false);
                }
            });
        
        return () => {
            cancelled = true;
        };
    }, deps);

    return <>
        {loading && <div style={{ textAlign: "center", height: 20 }} data-testid={"loading"}>
            ...loading
        </div>}
        {!loading && success && props.children(result!)}
    </>;
}
