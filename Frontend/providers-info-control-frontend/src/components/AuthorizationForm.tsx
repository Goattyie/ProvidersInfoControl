import React, { useState } from "react";
import Button from "./UI/buttons/Button";
import TextBox from "./UI/text-boxes/TextBox";
import { useNavigate } from "react-router-dom";

interface IAuthorizationFormProperties{
    width: number,
}

const Authorization = ({width} : IAuthorizationFormProperties) => 
{
    const divStyles = {
        'width' : width + 'px'
    }

    const navigate = useNavigate();
    const [login, setLogin] = useState('');
    const [password, setPassword] = useState('');

    const changeLogin = (e: React.FormEvent<HTMLInputElement>) : void => {  setLogin(e.currentTarget.value); }
    const changePassword = (e: React.FormEvent<HTMLInputElement>) : void => { setPassword(e.currentTarget.value); }

    const sendAuthorizeRequest = async (e: React.FormEvent) => {
        e.preventDefault();

        const api_host : string = process.env.REACT_APP_API_HOST as string; 
        var response = await fetch(api_host + 'api/authorization', {
            method: 'POST',
            headers: {
                Accept: 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                login: login,
                password: password
            })
        });

        const {result, errors} = await response.json();

        if(response.ok){
            if(errors === undefined){
                var token = result.token;
                
                localStorage.setItem('token', token);
                navigate("/own-types");
            }else{
                alert(errors);
            }
        }
    }

    return(
        <div style={divStyles}>
            <form onSubmit={sendAuthorizeRequest}>
                <TextBox text="Логин" OnChange={changeLogin} margin="10px 0px 10px 0px"/>
                <TextBox text="Пароль" OnChange={changePassword} margin="10px 0px 10px 0px"/>
                <Button text="Войти"/>
            </form>
        </div>
    );
}

const AuthorizationForm = ({width} : IAuthorizationFormProperties) => 
{
    return (
        <Authorization width={width} />
    );
}

export default AuthorizationForm;