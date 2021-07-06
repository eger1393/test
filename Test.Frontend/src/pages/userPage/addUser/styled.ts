import styled from "styled-components";

export const Container = styled.div`
  display: flex;
  flex-direction: column;
  max-width: fit-content;
  margin-top: 20px; 
`

export const FieldContainer = styled.div`
  display: flex;
  flex-direction: row;
  align-items: baseline;
  
  & > * {
    margin-right: 10px !important;
  }
  
  & > button{
    height: 40px;
    margin-left: 30px;
  }
  
`

export const ErrorContainer = styled.b`
  color: red;    
`