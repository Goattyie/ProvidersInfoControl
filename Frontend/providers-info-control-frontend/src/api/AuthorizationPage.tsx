import React from 'react';
import AuthorizationForm from '../components/AuthorizationForm';
import Label from '../components/UI/labels/Label';
import TextBox from '../components/UI/text-boxes/TextBox';

function AuthorizationPage() {
  return (
    <div className='auth-page'>
      <div className='auth-page-form'>
        <Label text='Авторизация' size={30}/>
        <AuthorizationForm width={400}/>
      </div>
    </div>);
}

export default AuthorizationPage;