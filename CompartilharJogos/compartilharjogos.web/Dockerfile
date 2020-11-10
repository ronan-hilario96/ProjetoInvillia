# estágio de compilação
FROM node:14-alpine as build-stage
WORKDIR /app
COPY ./CompartilharJogos/compartilharjogos.web/package*.json ./
RUN npm install
COPY ./CompartilharJogos/compartilharjogos.web .
RUN npm run build

# estágio de produção
FROM nginx:stable-alpine as production-stage
COPY --from=build-stage /app/dist /usr/share/nginx/html
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]