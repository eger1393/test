import React from 'react'
import {Route, Switch} from "react-router"
import UserPage from "./userPage";

const Pages = ({}) => {
    return (
        <Switch>
            <Route path={[`/`]}>
                <UserPage/>
            </Route>
        </Switch>
    )
};

export default Pages;