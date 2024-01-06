"use client";

import Link from "next/link";
import styles from "./styles.module.css";
import { usePathname } from "next/navigation";
import { ReactNode } from "react";

type Props = {
  title: string;
  children: ReactNode;
};

const ListContainer = ({ title, children }: Props) => {
  const pathname = usePathname();

  return (
    <section className={styles.container}>
      <h1 className={styles.title}>{title}</h1>
      <Link className={styles.createLink} href={`${pathname}/create`}>
        Novo
      </Link>
      {children}
    </section>
  );
};

export default ListContainer;
