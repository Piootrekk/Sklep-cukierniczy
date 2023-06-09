export interface ICartItem {
    id: string;
    name: string;
    amount: number;
    priceBrutto: number
}

export interface PropsCartItem extends ICartItem {
    onRemove: () => void;
    onAdd: () => void;
}
