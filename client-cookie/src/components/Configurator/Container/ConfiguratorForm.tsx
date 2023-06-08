import React, {useContext} from 'react';
import { useForm, Controller } from 'react-hook-form';
import { CakeContext, Ingredient } from "../../../storage/CustomCakeCont";
import { useAddNewCustomCake } from '../Repositories/configuratorRepositories';
import Select from './Select';

interface Categories {
    id: number,
    name: string,
    isActive: boolean,
    isDeleted: boolean
}
const MyForm: React.FC<{categories: Categories[]}> = ({categories}) => {
    const { control, handleSubmit, formState: { errors },  } = useForm<Ingredient>();
    const cakeContext = useContext(CakeContext);
    const addCake = useAddNewCustomCake()
    const onSubmit = (data: Ingredient) => {
        addCake({
            id: 123,
            name: data.name,
            description: data.description,
            priceBrutto: Number(data.priceBrutto),
            amountInStock: Number(data.amountInStock),
            categoryId: Number(data.categoryId),
            configurationPositionId: 4,
            images: [],
            isActive: true,
            isIngredient: false,
        })
    };

    if (!cakeContext) {
        return null;
    }
    return (
        <form onSubmit={handleSubmit(onSubmit)}>
            <div>
                <label htmlFor="name">Nazwa:</label>
                <Controller
                    control={control}
                    name="name"
                    rules={{ required: true }}
                    render={({ field }) => <input type="text" id="name" {...field} />}
                />
                {errors.name && <span>To pole jest wymagane!</span>}
            </div>

            <div>
                <label htmlFor="description">Opis:</label>
                <Controller
                    control={control}
                    name="description"
                    rules={{ required: true }}
                    render={({ field }) => <input type="text" id="description" {...field} />}
                />
                {errors.description && <span>To pole jest wymagane!</span>}
            </div>

            <div>
                <label htmlFor="priceBrutto">Cena:</label>
                <Controller
                    control={control}
                    name="priceBrutto"
                    rules={{ required: true }}
                    render={({ field }) => <input type="number" id="priceBrutto" {...field} />}
                />
                {errors.priceBrutto && <span>To pole jest wymagane!</span>}
            </div>

            <div>
                <label htmlFor="amountInStock">Ilość:</label>
                <Controller
                    control={control}
                    name="amountInStock"
                    rules={{ required: true }}
                    render={({ field }) => <input type="number" id="amountInStock" {...field} />}
                />
                {errors.priceBrutto && <span>To pole jest wymagane!</span>}
            </div>

            <Select control={control} name='categoryId' options={categories} />
            Lista składników:
            <div>
                <ul>
                    {cakeContext?.cake.ingredients.map(i => (
                        <li key={i.name}>{i.name}</li>
                    ))}
                </ul>
            </div>
            <button type="submit">Submit</button>
        </form>
    );
};

export default MyForm;