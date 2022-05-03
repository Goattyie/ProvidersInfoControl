import React, { useState } from 'react';

interface TextBoxProps{
    width?: number,
    margin?: string,
    text: string,
    value?: string,
    OnChange? : (e: React.FormEvent<HTMLInputElement>) => void
}

const TextBox = ({text, value, margin, width, OnChange} : TextBoxProps) => {

    const inputStyle = {
        'margin' : margin,
        'width' : width + 'px',
    }
    const [tbValue, setValue] = useState(text)


  return (
  <div className="form-group">
      <input className="form-control" style={inputStyle} placeholder={text} value={value} onChange = {OnChange}/>
  </div>);
}

export default TextBox;