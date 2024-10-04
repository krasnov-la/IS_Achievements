front-build:
	docker run --rm -ti -v ./frontend:/app -w /app --entrypoint '' node:16-alpine /bin/sh -c 'npm install && npm run build'