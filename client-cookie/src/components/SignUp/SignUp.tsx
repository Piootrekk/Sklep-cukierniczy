import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { useRegistrator } from './SignUpRepositories';

import Avatar from '@mui/material/Avatar';
import Button from '@mui/material/Button';
import CssBaseline from '@mui/material/CssBaseline';
import TextField from '@mui/material/TextField';
import Box from '@mui/material/Box';
import AssignmentIndOutlinedIcon from '@mui/icons-material/AssignmentIndOutlined';
import Typography from '@mui/material/Typography';
import Container from '@mui/material/Container';
import { createTheme, ThemeProvider } from '@mui/material/styles';

const defaultTheme = createTheme();

export default function SignUp() {
    const navigate = useNavigate();
    const signup = useRegistrator();
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const [confirmPassword, setConfirmPassword] = useState('');
    const [email, setEmail] = useState('');
    const [phoneNumber, setPhone] = useState('');
    const [cityName, setCity] = useState('');
    const [streetName, setStreetName] = useState('');
    const [houseNumber, setHouseNumber] = useState('');
    const [postalCode, setPostal] = useState('');
    const [firstName, setFirstName] = useState('');
    const [lastName, setLastName] = useState('');

    const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();
        try {
            const role = {
                    id: 1,
                    name: "User",
                    level: 1,
                    isActive: true,
                    isDeleted: false  
            }
            const response = signup({ username,
                email,
                password,
                confirmPassword,
                phoneNumber,
                streetName,
                cityName,
                houseNumber,
                postalCode,
                firstName,
                lastName, role });
            const token = await response;
            console.log(token.returnMesage);
            navigate('/');
        } catch (error) {
            console.error('Błąd rejestracji', error);
        }
    };

    const handlePhoneChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setPhone(event.target.value);
    };
    const handleCityChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setCity(event.target.value);
    };
    const handleHouseNumberChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setHouseNumber(event.target.value);
    };
    const handleStreetNameChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setStreetName(event.target.value);
    };
    const handlePostalCodeChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setPostal(event.target.value);
    };
    const handleEmailChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setEmail(event.target.value);
    };
    const handleUsernameChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setUsername(event.target.value);
    };
    const handleFirstNameChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setFirstName(event.target.value);
    };
    const handleLastNameChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setLastName(event.target.value);
    };
    const handlePasswordChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setPassword(event.target.value);
    };
    const handleConfirmPasswordChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setConfirmPassword(event.target.value);
    };
    return (
        <ThemeProvider theme={defaultTheme}>
            <Container component="main" maxWidth="xs">
                <CssBaseline />
                <Box
                    sx={{
                        marginTop: 8,
                        display: 'flex',
                        flexDirection: 'column',
                        alignItems: 'center',
                    }}
                >
                    <Avatar sx={{ m: 1, bgcolor: 'secondary.main' }}>
                        <AssignmentIndOutlinedIcon />
                    </Avatar>
                    <Typography component="h1" variant="h5">
                        Zarejestruj się
                    </Typography>
                    <Box component="form" onSubmit={handleSubmit} noValidate sx={{ mt: 1 }}>
                        <TextField
                            margin="normal"
                            required
                            fullWidth
                            id="firstName"
                            label="Imie"
                            name="firstName"
                            autoComplete="given-name"
                            value={firstName}
                            onChange={handleFirstNameChange}
                            autoFocus
                        />
                        <TextField
                            margin="normal"
                            required
                            fullWidth
                            id="lastName"
                            label="Nazwisko"
                            name="lastName"
                            autoComplete="family-name"
                            value={lastName}
                            onChange={handleLastNameChange}
                        />
                        <TextField
                            margin="normal"
                            required
                            fullWidth
                            id="email"
                            label="Email"
                            name="email"
                            autoComplete="email"
                            value={email}
                            onChange={handleEmailChange}
                        />
                        <TextField
                            margin="normal"
                            required
                            fullWidth
                            id="phoneNumber"
                            label="Numer telefonu"
                            name="phoneNumber"
                            autoComplete="tel"
                            value={phoneNumber}
                            onChange={handlePhoneChange}
                        />
                        <TextField
                            margin="normal"
                            required
                            fullWidth
                            id="cityName"
                            label="Miasto"
                            name="cityName"
                            autoComplete="address-level2"
                            value={cityName}
                            onChange={handleCityChange}
                        />
                        <TextField
                            margin="normal"
                            required
                            fullWidth
                            id="streetName"
                            label="Ulica"
                            name="streetName"
                            autoComplete="address-line1"
                            value={streetName}
                            onChange={handleStreetNameChange}
                        />
                        <TextField
                            margin="normal"
                            required
                            fullWidth
                            id="houseNumber"
                            label="Numer domu"
                            name="houseNumber"
                            autoComplete="address-line1"
                            value={houseNumber}
                            onChange={handleHouseNumberChange}
                        />
                        <TextField
                            margin="normal"
                            required
                            fullWidth
                            id="postalCode"
                            label="Kod pocztowy"
                            name="postalCode"
                            autoComplete="postal-code"
                            value={postalCode}
                            onChange={handlePostalCodeChange}
                        />
                        <TextField
                            margin="normal"
                            required
                            fullWidth
                            id="username"
                            label="login"
                            name="username"
                            autoComplete="username"
                            value={username}
                            onChange={handleUsernameChange}
                        />
                        <TextField
                            margin="normal"
                            required
                            fullWidth
                            name="password"
                            label="Hasło"
                            type="password"
                            id="password"
                            autoComplete="current-password"
                            value={password}
                            onChange={handlePasswordChange}
                        />
                        <TextField
                            margin="normal"
                            required
                            fullWidth
                            name="confirmPassword"
                            label="Potwierdź Hasło"
                            type="password"
                            id="confirmPassword"
                            autoComplete="current-password"
                            value={confirmPassword}
                            onChange={handleConfirmPasswordChange}
                        />
                        <Button
                            type="submit"
                            fullWidth
                            variant="contained"
                            style={{ background: '#8a2b06' }}
                            sx={{ mt: 3, mb: 2 }}
                        >
                            Zarejestruj
                        </Button>
                        <Button onClick={() => navigate('/')}>
                            Logowanie
                        </Button>
                    </Box>
                </Box>
            </Container>
        </ThemeProvider>
    );
}