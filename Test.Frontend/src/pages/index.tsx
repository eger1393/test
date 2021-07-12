import React from 'react'
import {Route, Switch} from "react-router"
import UserPage from "./userPage";
import MainLayout, { PageNames } from "../layouts/mainLayout";
import AnalyticsPage from "./analyticsPage";

const Pages = ({}) => {
    return (
        <Switch>
            <Route path={PageNames.analytics}>
                <MainLayout selectedMenuItem={PageNames.analytics}>
                    <AnalyticsPage/>
                </MainLayout>
            </Route>
            <Route path={PageNames.data}>
                <MainLayout selectedMenuItem={PageNames.data}>
                    <UserPage/>
                </MainLayout>
            </Route>

        </Switch>
    )
};

export default Pages;
