import axios from "axios";

const _baseUrl = 'http://localhost:3000';

export const api = axios.create({baseURL: _baseUrl});