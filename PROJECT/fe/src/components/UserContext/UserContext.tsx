import React, { createContext, useCallback } from 'react';
import { useContext } from 'react';
import { useHistory } from 'react-router-dom';
import { useSessionStorage } from '../../hooks/useSessionStorage';
import { fetcher } from '../../utils/fetcher';

export interface UserData {
  idUser: number,
  firstName: string,
  lastName: string,
  userName: string,
  email: string,
  icon: string | null,
  isSeller: boolean,
  isBuyer: boolean,
  selfPickupAddress: string,
  phoneNumber: string
}

export interface UserContextType {
  data: UserData | null
  logIn: (username: string) => void
  logOut: () => void
}

export const UserContext = createContext<UserContextType>({
  data: null,
  logIn: () => {},
  logOut: () => {}
});

export const UserContextProvider: React.FC = ({ children }) => {
  const [userData, setUserData] = useSessionStorage<UserData | null>("userData", null)
  const history = useHistory()

  const logIn = useCallback(async (username: string) => {
    const response = await fetcher('/api/auth/login', {
      method: 'POST',
      body: JSON.stringify({
        username,
      }),
      headers: {
        "Content-Type": "application/json"
      }
    })

    setUserData(response);
  }, [setUserData])

  const logOut = useCallback(() => {
    setUserData(null);
    history.push("/")
  }, [history, setUserData])

  const value = {
    data: userData,
    logIn,
    logOut,
  }

  return (
    <UserContext.Provider value={value}>
      {children}
    </UserContext.Provider>
  );
}

export const useUserData = () => {
  const context = useContext(UserContext);

  return context;
}
