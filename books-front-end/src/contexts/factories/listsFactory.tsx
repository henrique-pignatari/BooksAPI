import { ReactNode, createContext, useState } from "react";

type ListContextData<T> = {
  list: Array<T>
  addNew: (element: T) => void
}

export function createListContext<T>(){
  return createContext<ListContextData<T>>({} as ListContextData<T>)
}

function listProviderFactory<T>(){
  const context = createListContext<T>();
  
  const ProviderElement = (children: ReactNode) => {
    const [list, setList] = useState<Array<T>>([]);

    const addNew = (element: T) => {
      const proxyList = [...list]
      proxyList.push(element)
      setList(proxyList)
    }

    return(
      <context.Provider value={{ list, addNew }}>
        {children}
      </context.Provider>
    )
  }

  return{
    ProviderElement,
    context
  }
}

export {
  listProviderFactory
}

