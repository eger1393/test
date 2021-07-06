import styled from 'styled-components'

export const Container = styled.div`
  height: fit-content;
  padding: 20px;
  
  .New-Row{
    background-color: rgba(131, 255, 110, 0.65)
  }

  .New-Row.MuiDataGrid-row:hover{
    background-color: rgba(131, 255, 110, 0.8)
  }
`

export const ButtonContainer = styled.div`
  width: 100%;
  display: flex;
  justify-content: flex-end;
  margin-top: 20px;
  & > button{
    margin-right: 20px;
    
  }
`