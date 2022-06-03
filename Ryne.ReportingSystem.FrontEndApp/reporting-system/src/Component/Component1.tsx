import React from 'react'

type Props = {
  name: string
}

export default function Component1({name}: Props) {
  return (
    <div>
      <h1 style={{color:'red'}} >{name}</h1>
    </div>
  )
}