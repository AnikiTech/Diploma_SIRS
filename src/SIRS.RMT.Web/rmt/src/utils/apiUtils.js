function sleep(ms) {
    return new Promise(resolve => setTimeout(resolve, ms));
}


export const api = async (username, password) => {
    await sleep(1000);
    return await (username === "test" & password === "123") ? "3e0cb5efcd52300aec5994fdfc5bdc16" : "";
};