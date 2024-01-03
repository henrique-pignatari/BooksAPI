import React from "react";

import styles from "./styles.module.css";
import Link from "next/link";
import routes from "@/global/routes";

const Navbar = () => {
  return (
    <nav className={styles.container}>
      <ul className={styles.linkList}>
        {routes.map((route, index) => {
          console.log({ route });
          return (
            <li key={index}>
              <Link className={`${styles.link} ${styles[`link-${route.color}`]}`} href={route.link}>
                {route.title}
              </Link>
            </li>
          );
        })}
      </ul>
    </nav>
  );
};

export default Navbar;
