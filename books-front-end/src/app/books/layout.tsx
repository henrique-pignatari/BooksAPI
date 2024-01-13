import { BooksListProvider } from "@/contexts/booksList";
import { ReactNode } from "react";

type Props = {
  children: ReactNode
}

const BooksLayout = ({children}: Props) => {
  return (
    <BooksListProvider>
      {children}
    </BooksListProvider>
  );
}
 
export default BooksLayout;