FROM node:latest

WORKDIR /MachineCartSystem.UI
COPY MachineCartSystem.UI/package*.json ./

RUN npm install
COPY MachineCartSystem.UI ./

CMD ["npm", "start"]

