import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'Insurance_v1',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44327/',
    redirectUri: baseUrl,
    clientId: 'Insurance_v1_App',
    responseType: 'code',
    scope: 'offline_access Insurance_v1',
    requireHttps: true,
  },
  apis: {
    default: {
      url: 'https://localhost:44327',
      rootNamespace: 'yocar.Insurance_v1',
    },
  },
} as Environment;
