export const dev = window.location.origin.includes('localhost')
export const baseURL = dev ? 'https://localhost:7045' : ''
export const useSockets = false
// TODO use your own auth stuff
export const domain = 'dev-mrvk3568vveue5j1.us.auth0.com'
export const clientId = 'jFQR5cCT2hNPilRKBBqSCRHTILLGwaJX'
export const audience = 'https://auth.buglog.com'