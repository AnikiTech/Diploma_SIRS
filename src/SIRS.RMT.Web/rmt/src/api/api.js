import axios from "axios";
import config from '../../config/config.js'

// API instance
const api = axios.create({    
    baseURL: config.API_ENDPOINT,
    timeout: 1000 * 10,
});

export default api;