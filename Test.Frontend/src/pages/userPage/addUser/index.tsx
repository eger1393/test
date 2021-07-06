import React, {useState} from "react";
import {Container, ErrorContainer, FieldContainer} from "./styled";
import DateFnsUtils from '@date-io/date-fns';
import {
    MuiPickersUtilsProvider,
    KeyboardDatePicker,
} from '@material-ui/pickers';
import {ru} from "date-fns/locale";
import {Button} from "@material-ui/core";

interface IAddUserField {
    registrationDate?: Date,
    lastActivityDate?: Date,
}

export interface IAddUser {
    handleAddUser: (registrationDate: Date, lastActivityDate: Date) => void;
}

export const AddUser = ({handleAddUser}: IAddUser) => {
    const [fields, setFields] = useState<IAddUserField>({});
    const [error, setError] = useState<string | undefined>();

    const handleDateChange = (fieldKey: keyof (IAddUserField)) => (date: Date | null) => {
        setFields(prev => ({...prev, [fieldKey]: date}));
        setError(undefined);
    };

    const handleAdd = () => {
        if (!validate())
            return;

        handleAddUser(fields.registrationDate as Date, fields.lastActivityDate as Date)
        setFields({})
        setError(undefined)
    }

    const validate = (): boolean => {
        if (!fields.lastActivityDate || !fields.registrationDate) {
            setError('Fill in all the fields');
            return false;
        }
        if (fields.lastActivityDate < fields.registrationDate) {
            setError('The date of the last activity cannot be less than the registration date');
            return false;
        }
        return true;
    }
    return <Container>
        <b>Add new record</b>
        <FieldContainer>
            <MuiPickersUtilsProvider utils={DateFnsUtils} locale={ru}>
                <KeyboardDatePicker
                    autoOk={true}
                    disableToolbar
                    variant="inline"
                    format="dd.MM.yyyy"
                    margin="normal"
                    label="Date Registration"
                    id="date-picker-inline"
                    value={fields.registrationDate ?? null}
                    onChange={handleDateChange("registrationDate")}
                />
                <KeyboardDatePicker
                    autoOk={true}
                    disableToolbar
                    variant="inline"
                    format="dd.MM.yyyy"
                    margin="normal"
                    label="Date Last Activity"
                    value={fields.lastActivityDate ?? null}
                    onChange={handleDateChange("lastActivityDate")}
                />
            </MuiPickersUtilsProvider>
            <Button variant="outlined" onClick={handleAdd}>Add</Button>
        </FieldContainer>
        {error && <ErrorContainer>{error}</ErrorContainer>}
    </Container>
}

export default AddUser