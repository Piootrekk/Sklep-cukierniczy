import { defineConfig, loadEnv } from 'vite'
import react from '@vitejs/plugin-react'

// https://vitejs.dev/config/
export default defineConfig(async ({
  command, mode
}) => {
  process.env = {...process.env, ...loadEnv(mode, process.cwd())};
  return {
    plugins: [react()],
    define: {
      APP_API_BASEURL: process.env.APP_API_BASEURL,
    },
  }
})
