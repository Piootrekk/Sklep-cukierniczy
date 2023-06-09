import { Checkbox, Grid, SelectChangeEvent, TextField } from '@mui/material';
import React, { useState } from 'react';
import { Controller, useForm } from 'react-hook-form';
import Select from '../Configurator/Container/Select';
import { Categories } from '../Configurator/Container/ConfiguratorForm';
import { useAddNewProduct } from '../Configurator/Repositories/configuratorRepositories';
import classes from "../Cart/Cart.module.css";


type ImageData = {
    id: number;
    name: string;
    url: string;
    added: string;
    isDeleted: boolean;
};

type FormData = {
    name: string;
    description: string;
    isIngredient: boolean;
    categoryId: number;
    images: ImageData[];
    configurationPositionId: number;
    priceBrutto: number;
    amountInStock: number;
    isActive: boolean;
};

const CakesForm: React.FC<{ categories: Categories[], productNumber: number, onClose: () => void, refresh: () => void }> = ({ categories, productNumber, onClose, refresh }) => {
    const { control, handleSubmit, formState: { errors } } = useForm<FormData>({
        defaultValues: {
            name: '',
            description: '',
            isIngredient: false,
            categoryId: 1,
            configurationPositionId: 5,
            priceBrutto: 1,
            amountInStock: 1,
            isActive: true
        }
    });
    const [categoriesList] = useState(categories)
    const [productLength] = useState(productNumber)
    const addNewProduct = useAddNewProduct();
    const [categoryId, setSelectedValue] = useState('');
    const setCategoryId = (e: SelectChangeEvent) => {
        setSelectedValue(e.target.value);
    }
    const onSubmit = async (data: FormData) => {
        try {
            await addNewProduct({
                id: productLength + 1,
                amountInStock: 1,
                categoryId: Number(categoryId),
                configurationPositionId: Number(data.configurationPositionId),
                description: data.description,
                images:  [],
                isActive: true,
                isIngredient: data.isIngredient,
                name: data.name,
                priceBrutto: Number(data.priceBrutto),
            })
            onClose();
            refresh();
        } catch {
            throw new Error('Nie udało się dodac produktu')
        }
    };

    return (
        <form onSubmit={handleSubmit(onSubmit)}>
            <h3>Dodaj nowy produkt</h3>
            <Grid container spacing={2}>
                <Grid item xs={6}>
                    <label htmlFor="name">Nazwa:</label>
                    <Controller
                        control={control}
                        name="name"
                        rules={{ required: true }}
                        render={({ field }) => <TextField fullWidth type="text" id="name" {...field} />}
                    />
                    {errors.name && <span style={{ color: 'red' }}>To pole jest wymagane!</span>}
                </Grid>
                <Grid item xs={6}>
                    <label htmlFor="description">Opis:</label>
                    <Controller
                        control={control}
                        name="description"
                        rules={{ required: true }}
                        render={({ field }) => <TextField fullWidth type="text" id="description" {...field} />}
                    />
                    {errors.description && <span style={{ color: 'red' }}>To pole jest wymagane!</span>}
                </Grid>
                <Grid item xs={6}>
                    <Select categoryId={categoryId} setCategoryId={(e: SelectChangeEvent) => setCategoryId(e)} control={control} name='categoryId' options={categoriesList} />
                </Grid>
                <Grid item xs={6}>
                    <label htmlFor="configurationPositionId">Ustal pozycję składnika:</label>
                    <Controller
                        control={control}
                        name="configurationPositionId"
                        rules={{ required: true }}
                        render={({ field }) => <TextField fullWidth type="number" id="configurationPositionId" {...field} />}
                    />
                    {errors.configurationPositionId && <span style={{ color: 'red' }}>To pole jest wymagane!</span>}
                </Grid>
                <Grid item xs={6}>
                    <label htmlFor="priceBrutto">Cena:</label>
                    <Controller
                        control={control}
                        name="priceBrutto"
                        rules={{ required: true }}
                        render={({ field }) => <TextField fullWidth type="number" id="priceBrutto" {...field} />}
                    />
                    {errors.priceBrutto && <span style={{ color: 'red' }}>To pole jest wymagane!</span>}
                </Grid>
                <Grid style={{ display: 'grid' }} item xs={6}>
                    <label htmlFor="isIngredient">Czy ciasto jest też składnikiem?</label>
                    <Controller
                        control={control}
                        name="isIngredient"
                        render={({ field }) =>
                            <Checkbox style={{ width: 30 }} id="isIngredient" {...field} />
                        }
                    />
                    {errors.isIngredient && <span style={{ color: 'red' }}>To pole jest wymagane!</span>}
                </Grid>
                <div className={classes.actions} style={{ width: '100%', display: 'flex', justifyContent: 'end' }}>
                    <button className={classes.button}  type="submit">Zapisz</button>
                </div>
            </Grid>
        </form>
    );
};

export default CakesForm;