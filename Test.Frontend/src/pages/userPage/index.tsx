import React, {useEffect, useState} from 'react'
import {DataGrid, GridColDef, GridRowData, GridRowId, GridRowParams} from '@material-ui/data-grid';
import {ButtonContainer, Container} from "./styled";
import AddUser from "./addUser";
import {Button} from "@material-ui/core";
import {IUser} from "../../models/user";
import {apiAddUsers, apiDeleteAllUsers, apiGetUsers} from "../../api/apiUser";
import {createDateAsUTC, dateConverter} from "../../helpers/dateHelper";

const columns: GridColDef[] = [
    {
        field: 'id',
        headerName: 'ID',
        type: "string",
        flex: 10,
        valueGetter: params => params.value ?? 'new item'
    },
    {
        field: 'registrationDate',
        headerName: 'Date Registration',
        type: "date",
        valueFormatter: (params) =>  (params.value as Date)?.toLocaleDateString(),
        sortable: true,
        flex: 20,
    },
    {
        field: 'lastActivityDate',
        headerName: 'Date Last Activity',
        type: "date",
        valueFormatter: (params) =>  (params.value as Date)?.toLocaleDateString(),
        sortable: true,
        flex: 20,
    },
];
export const UserPage = () => {
    const [users, setUsers] = useState<Array<IUser>>([]);
    const [isLoading, setIsLoading] = useState(true)

    useEffect(() => {
        // noinspection JSIgnoredPromiseFromCall
        updateData()
    }, [])

    const updateData = async () => {
        setIsLoading(true);
        let data = await apiGetUsers();
        setUsers(data);
        setIsLoading(false);
    }

    const handleAddUser = (registrationDate: Date, lastActivityDate: Date) => {
        setUsers(prev => ([...prev, {
            registrationDate: createDateAsUTC(registrationDate),
            lastActivityDate: createDateAsUTC(lastActivityDate),
            tableId: prev.length
        }]))
    }

    const getRowClassName = (params: GridRowParams) => {
        return !params.row.id ? 'New-Row' : '';
    }

    const handleSave = async () => {
        await apiAddUsers(users.filter(x => !x.id))
        await updateData();
    }

    const handleDeleteAll = async () => {
        await apiDeleteAllUsers();
        await updateData();
    }

    if (isLoading) return <>Loading...</>

    return <Container>
        <DataGrid rows={users} columns={columns} autoHeight={true} autoPageSize={false} hideFooter={true}
                  getRowClassName={getRowClassName} getRowId={(row: GridRowData) => row.tableId}/>
        <ButtonContainer>
            <Button onClick={handleSave} variant="outlined" disabled={!users.some(x => !x.id)}>Save</Button>

            <Button onClick={handleDeleteAll} variant="outlined" disabled={users.length === 0}>Delete all</Button>
        </ButtonContainer>
        <AddUser handleAddUser={handleAddUser}/>
    </Container>
}

export default UserPage
