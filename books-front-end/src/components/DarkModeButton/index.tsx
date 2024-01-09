"use client";
import { useState } from "react";

const DarkModeButton = () => {
  const [isDarkMode, setIsDarkMode] = useState(false);

  const toggleTheme = () => {
    setIsDarkMode(!isDarkMode);
    document.documentElement.classList.toggle("dark");
  };

  return (
    <button className="toggleButton" onClick={toggleTheme}>
      {isDarkMode ? <strong>DARK</strong> : <strong>LIGHT</strong>}
    </button>
  );
};

export default DarkModeButton;
