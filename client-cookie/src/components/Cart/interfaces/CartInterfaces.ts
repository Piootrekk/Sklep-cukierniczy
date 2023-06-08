export interface ICartItem {
    id: number;
    name: string;
    amount: number;
    price: number
}

export interface PropsCartItem extends ICartItem {
    onRemove: () => void;
    onAdd: () => void;
}
