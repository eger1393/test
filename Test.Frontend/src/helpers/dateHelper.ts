export const createDateAsUTC = (date: Date) => {
    return new Date(Date.UTC(
        date.getFullYear(),
        date.getMonth(),
        date.getDate(),
        date.getHours(),
        date.getMinutes(),
        date.getSeconds())
    );
}

export const dateConverter = (date: string) =>
    date.indexOf('Z') === -1 ? new Date(date) : new Date(date.slice(0, date.indexOf('Z')));