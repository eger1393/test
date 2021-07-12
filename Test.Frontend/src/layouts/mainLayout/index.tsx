import React, {useEffect, useState} from 'react'
import {Container, ContentContainer} from "./styled";
import {Drawer, List, ListItem, ListItemText} from "@material-ui/core";
import {useHistory} from "react-router";

export enum PageNames {
    data = '/',
    analytics = '/analytics',
}

interface IMainLayout {
    children: React.ReactNode | React.ReactNodeArray,
    selectedMenuItem: PageNames,
}

const MainLayout = ({children, selectedMenuItem}: IMainLayout) => {
    const history = useHistory();

    return (<Container>
        <Drawer
            variant={"permanent"}
            style={{position: "fixed"}}
        >
            <List>
                <ListItem
                    button
                    selected={selectedMenuItem === PageNames.data}
                    onClick={() => history.push(PageNames.data)}
                >
                    <ListItemText primary={"Data"}/>
                </ListItem>
                <ListItem
                    button
                    selected={selectedMenuItem === PageNames.analytics}
                    onClick={() => history.push(PageNames.analytics)}
                >
                    <ListItemText primary={"Analytics"}/>
                </ListItem>
            </List>
        </Drawer>
        <ContentContainer>
            {children}
        </ContentContainer>
    </Container>)
};

export default MainLayout
