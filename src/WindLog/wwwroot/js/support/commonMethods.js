function parseDate(dateToParse) {
    var year, month, day;

    year = dateToParse.slice(0, 4);
    month = dateToParse.slice(5, 7) - 1;
    day = dateToParse.slice(8, 10);

    return new Date(year, month, day, 23, 0, 0);
}