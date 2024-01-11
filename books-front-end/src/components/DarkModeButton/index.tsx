"use client";
import { useState } from "react";
import styles from "./styles.module.scss"
import { IconContext } from "react-icons";
import { IoMoon, IoSunny } from "react-icons/io5";

const LightModeButton = () => {
  const [isLightMode, setIsLightMode] = useState(false);

  const toggleTheme = () => {
    setIsLightMode(!isLightMode);
    document.documentElement.classList.toggle("light");
  };

  return (
    <button className={styles.toggleButton} onClick={toggleTheme}>
      <IconContext.Provider value={{className: styles.icon}}>
        {isLightMode ? <IoMoon /> : <IoSunny />}
      </IconContext.Provider>
    </button>
  );
};

export default LightModeButton;
