import axios from 'axios';
import { ITimeSpanUser } from '../models/timeSpanUser';

export const apiGetRollingRetention = (days: number) => axios.get(`api/analytic/rollingRetention`,{params: {days: days}}).then(res => res.data);

export const apiGetLifeSpanUsers = () => axios.get<Array<ITimeSpanUser>>(`api/analytic/lifeSpanUsers`).then(res => res.data)
