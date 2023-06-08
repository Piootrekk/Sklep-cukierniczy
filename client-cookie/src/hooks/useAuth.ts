import { useEffect, useState } from "react";

export const useAuth = () => {
    const [isLoggedIn, setIsLoggedIn] = useState(false);
    const loggedInUser = localStorage.getItem('token');

    useEffect(() => {
        if (loggedInUser) {
            return setIsLoggedIn(true);
        }
        else {
            setIsLoggedIn(false);
        }
    }, [loggedInUser]);

    return isLoggedIn
};