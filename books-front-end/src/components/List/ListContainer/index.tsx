"use client";

import Link from "next/link";
import styles from "./styles.module.scss";
import { usePathname } from "next/navigation";
import { ReactNode } from "react";
import Image from "next/image";
import singleArrow from "../../../assets/single-arrow.svg";
import doubleArrow from "../../../assets/double-arrow.svg";
import { FiChevronLeft, FiChevronRight, FiChevronsLeft, FiChevronsRight } from "react-icons/fi";
import { IconContext } from "react-icons";

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
            <IconContext.Provider value={{className: styles.icons}}>
              <button className={`${styles.paginationButton}`}>
                <FiChevronsLeft />
              </button>
              <button className={`${styles.paginationButton}`}>
                <FiChevronLeft />
              </button>

              <button className={`${styles.paginationButton}`}>
                <FiChevronRight />
              </button>
              <button className={`${styles.paginationButton}`}>
                <FiChevronsRight />
              </button>
            </IconContext.Provider>
          </div>
        </div>
        {children}
      </div>
    </section>
  );
};

export default ListContainer;
