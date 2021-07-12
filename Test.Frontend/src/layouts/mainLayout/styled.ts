import styled from 'styled-components'

export const Container = styled.div`
  width: 100vw;
  height: 100vh;
  position: relative;

  .MuiDrawer-paper{
    width: 250px;
    height: 100vh;
    position: relative;
    z-index: 0;

  }
  .Mui-selected{
    color: #3F51B5;
    svg {
      fill: #3F51B5;

      path{
        fill: #3F51B5;
      }
    }
  }
`;

export const ContentContainer = styled.div`
  margin-left: 250px;
  margin-bottom: 20px;
`;
