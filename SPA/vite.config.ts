import { defineConfig } from "vite";
import react from "@vitejs/plugin-react";
import path from "path";
import { TanStackRouterVite } from "@tanstack/router-plugin/vite";
// https://vitejs.dev/config/
export default defineConfig({
  plugins: [react(), TanStackRouterVite()],
  resolve: {
    alias: {
      "#assets": path.resolve(__dirname, "./src/assets"),
      "#hooks": path.resolve(__dirname, "./src/hooks"),
      "#schema": path.resolve(__dirname, "./src/schema"),
      "#utils": path.resolve(__dirname, "./src/utils"),
      "#components": path.resolve(__dirname, "./src/components"),
    },
  },
});
