import type { Metadata } from "next";
import "./globals.scss";
import Navbar from "@/components/Navbar";
import DarkModeButton from "@/components/DarkModeButton";

export const metadata: Metadata = {
  title: "Livros",
  description: "Aplicação para catalogar e controlar livros",
};

export default function RootLayout({ children }: { children: React.ReactNode }) {
  return (
    <html lang="pt-br">
      <body>
        <header>
          <Navbar />
          <DarkModeButton/>
        </header>
        <main>{children}</main>
      </body>
    </html>
  );
}
