import React, { useState } from 'react';

interface IButton{
    text : string,
}

const Button = ({text} : IButton) => {
    return(
        <div className='d-flex justify-content-center'>
            <button type="submit" className="btn btn-primary">{text}</button>
        </div>);
}

export default Button;