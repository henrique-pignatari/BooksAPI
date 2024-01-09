"use client";

import Link from "next/link";
import styles from "./styles.module.scss";
import { usePathname } from "next/navigation";
import { ReactNode } from "react";
import Image from "next/image";
import singleArrow from "../../../assets/single-arrow.svg";
import doubleArrow from "../../../assets/double-arrow.svg";

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
      <div className={styles.listContainer}>
        <div className={styles.listHeader}>
          <div className={styles.paginationWrapper}>
            <button className={`${styles.paginationButton} ${styles.arrowLeft}`}>
              <Image src={singleArrow} alt="" />
            </button>
            <button className={`${styles.paginationButton} ${styles.arrowLeft}`}>
              <Image src={doubleArrow} alt="" />
            </button>

            <button className={`${styles.paginationButton} ${styles.arrowRight}`}>
              <Image src={doubleArrow} alt="" />
            </button>
            <button className={`${styles.paginationButton} ${styles.arrowRight}`}>
              <Image src={singleArrow} alt="" />
            </button>
          </div>
        </div>
        {children}
      </div>
    </section>
  );
};

export default ListContainer;
