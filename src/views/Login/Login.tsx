import React, { useState } from "react";
import { useUserData } from "../../components/UserContext/UserContext";

export const Login = () => {
  const [userName, setUserName] = useState('');
  const [error, setError] = useState<string | null>(null);
  const { logIn } = useUserData();

  const onSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    setError(null)

    if (!userName) {
      setError('Nazwa użytkownika jest wymagana.')
    }

    try {
      await logIn(userName);
    } catch (error) {
      setError('Nazwa użytkownika lub hasło są błędne.')
    }
  }

  const onChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setUserName(e.target.value);
  }

  return (
    <form onSubmit={onSubmit}>
      <label>
        <div>Login</div>
        <input type="text" name="login" id="login" value={userName} onChange={onChange} />
      </label>
      <label>
        <div>Hasło</div>
        <input type="text" name="password" id="password" />
      </label>
      <div>
        <strong>{error}</strong>
      </div>
      <div>
        <button>Zaloguj się</button>
      </div>
    </form>
  );
}
