import axios from 'axios'
import {IUser} from "../models/user";
import {dateConverter} from "../helpers/dateHelper";

export const apiGetUsers = () => axios.get(`api/user`).then(res => normalizeUser(res.data))

export const apiAddUsers = (users: Array<IUser>) =>
    axios.post(`api/user/create`, users).then(res => res.data)

const normalizeUser = (data: any) => (data ?? []).map((x: any, i: number) => ({
    ...x,
    registrationDate: dateConverter(x.registrationDate),
    lastActivityDate: dateConverter(x.lastActivityDate),
    tableId: i
}))