import { Button } from '@material-ui/core';
import React, {useEffect, useState} from 'react'
import { Bar } from 'react-chartjs-2';
import {apiGetLifeSpanUsers, apiGetRollingRetention} from "../../api/apiAnalytic";
import { Container } from './styled';

const rollingRetentionDayCount = 7;

const config = {
    scales: {
        x:{
            title: {
                display: true,
                text: 'LifeSpan Days'
            },
        },
        y:{
            title: {
                display: true,
                text: 'Count'
            },
            ticks:{
                stepSize: 1
            }
        }
    }
}

const AnalyticsPage = ({}) => {
    const [rollingRetention, setRollingRetention] = useState<number | undefined>();
    const [data, setData] = useState<any>(undefined);

    const handleGetRollingRetention = async () => {
        let res = await apiGetRollingRetention(rollingRetentionDayCount);
        setRollingRetention(res);
        let lifeSpans  = await apiGetLifeSpanUsers();
        setData({
            labels: lifeSpans.map(x => x.lifeSpanDays),
            datasets: [
                {
                    label: '# LifeSpan Days',
                    data: lifeSpans.map(x => x.count),
                    backgroundColor: 'rgba(255, 99, 132, 0.2)'
                },
            ],
        });
    }

    return (<Container>
        <Button variant="outlined" onClick={handleGetRollingRetention}>Calculate</Button>
        {rollingRetention && <span>Rolling Retention 7 day: <b>{rollingRetention}</b>%</span>}

        {data && <Bar data={data}  type="bar" options={config}/> }
    </Container>)
};

export default AnalyticsPage
