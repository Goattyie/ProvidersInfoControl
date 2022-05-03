import React, { useState } from 'react';

interface ILabelProperties{
    text: string,
    size: number
}

const Label = ({text, size} : ILabelProperties) => {

    const divStyle = {
        'display': 'flex', 
        'justifyContent': 'center',
        'marginBottom' : 30 + 'px'
    }

  return (
  <div style={divStyle}>
      <label style={{fontSize : size}}>{text}</label>
  </div>);
}

export default Label;