interface ImportMetaEnv {
  VITE_BACKEND_API_BASE_URL: string;
  // Add other VITE_ prefixed environment variables here if needed
}

interface ImportMeta {
  readonly env: ImportMetaEnv;
}
