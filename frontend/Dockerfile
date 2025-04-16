# Etapa de build
FROM node:20 AS build
WORKDIR /app

# Copia somente os arquivos necessários primeiro (para cache eficiente)
COPY ./accruent-front/package.json ./package.json
COPY ./accruent-front/package-lock.json ./package-lock.json

# Instala dependências
RUN npm install

# Copia o restante do projeto
COPY ./accruent-front/ .

# Gera o build de produção
RUN npm run build --prod

# Etapa do Nginx
FROM nginx:alpine

# Copia os arquivos de build Angular para o Nginx
COPY --from=build /app/dist/accruent-front/browser /usr/share/nginx/html

EXPOSE 80

CMD ["nginx", "-g", "daemon off;"]
